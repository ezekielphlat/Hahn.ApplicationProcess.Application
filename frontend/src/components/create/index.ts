import {ValidationRules, ValidationControllerFactory} from 'aurelia-validation';
import {inject} from 'aurelia-framework'
import { ObserverLocator } from 'aurelia-framework';
import { HttpClient, json } from 'aurelia-fetch-client';
import {EventAggregator} from 'aurelia-event-aggregator';
import {Router} from 'aurelia-router';
import {DialogService} from 'aurelia-dialog';
import {Prompt} from '../modal/prompt';

let httpClient = new HttpClient()
let baseUrl = "http://localhost:5000/api/Asset";
@inject(ValidationControllerFactory,ObserverLocator,EventAggregator,Router,DialogService)
export class Create{
    dialogService:any;
    assetContainsValue= false;
    errorMessage:any;
    router: any;
    hasError = false;     
    isBroken =false;
    controller: any;
    asset : any;
    departments = [
        { id: 1, name: 'HQ' },
        { id: 2, name: 'Store1' },
        { id: 3, name: 'Store2' },
        { id: 4, name: 'Store3' },
        { id: 5, name: 'MaintenanceStation' },
      ];
    selectedDepartmentID = null;
    eventAggregator: any;
    constructor(validationControllerFactory,observerLocator, eventAggregator, router,dialogService){
        this.controller = validationControllerFactory.createForCurrentScope();
        var subscription = observerLocator
            .getObserver(this, 'asset')
            .subscribe(this.onAssetChange.bind(this));  
            
            this.eventAggregator = eventAggregator;
            this.router = router;
            this.dialogService = dialogService;
    }
    openModal(asset) {
        this.dialogService.open( {viewModel: Prompt, model:this.asset }).then(response => {
           console.log(response);
              
           if (!response.wasCancelled) {
              this.asset = null;
           } else {
               this.asset = asset
              console.log('cancelled');

           }
           console.log(response.output);
        });
     }
    
    submitAsset(){
        this.controller.validate();
        this.asset.isBroken = this.isBroken;
        this.asset.date = new Date(this.asset.date).toISOString ();
        httpClient.fetch(baseUrl, {
            method: "POST",
            body: JSON.stringify(this.asset)
        }).then(response => response.json())
        .then(data => {
            this.hasError = false;
            this.eventAggregator.publish('assetStatus', "Created");
            this.router.navigateToRoute('post-success');
            console.log(data);
        }).catch(error => {
            this.hasError = true;
            this.errorMessage = error;
            console.log(error);
        })

        console.log(this.asset);
    }
   
    onAssetChange(){
        if(this.asset){
            
            console.log(this.assetContainsValue)
            ValidationRules.ensure('name')
            .required().minLength(5)
            .ensure('department').required()
            .ensure('country')
            .required()
            .ensure('email')
            .required().email()
            .ensure('date')
            .required()
            .on(this.asset);
            
        }
    }
}