import {HttpClient, json} from 'aurelia-fetch-client';
import {DialogService} from 'aurelia-dialog';
import {EditAssetModal} from '../modal/edit_asset'
import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

let httpClient = new HttpClient()
let baseUrl = "https://localhost:5001/api/Asset";

@inject(DialogService,Router)
export class Home{    
    assetData: any;
    dialogService: any;
    router: any;
    eventAggregator: any;
    constructor(dialogService,router){
        this.getAllAssets();
        this.dialogService = dialogService; 
        this.router = router; 
      
    }

    openModal(asset) {
        this.dialogService.open( {viewModel: EditAssetModal, model: asset }).whenClosed(response => {
           console.log(response);
              
           if (!response.wasCancelled) {
              console.log(asset);
              this.updateAsset(asset.id, asset)

           } else {
              console.log('cancelled');
           }
           console.log(response.output);
        });
     }
     updateAsset(id,asset) {
        httpClient.fetch(baseUrl+'/'+id, {
           method: "PUT",
           body: JSON.stringify(asset)
        })
          
        .then(response => response.json())
        .then(data => {
           console.log(data);
           this.router.navigateToRoute('post-success');
        });
     }

    getAllAssets(){
        httpClient.fetch(baseUrl)
        .then(response => response.json())
        .then(res => {   
            console.log(res.data)       
            this.assetData = res.data    
        });
    }
    editAsset(asset){
        console.log(asset);
        this.openModal(asset);
    }
    deleteAsset(id){
        console.log("asset id: "+id);
        httpClient.fetch(baseUrl + '/'+id, {
            method: "DELETE"
         })
         .then(response => response.json())
         .then(data => {
            console.log(data);
            this.router.navigateToRoute('post-success');
         });
    }
}