import {ValidationRules, ValidationControllerFactory} from 'aurelia-validation';
import {inject} from 'aurelia-framework'
import {bindable} from 'aurelia-framework'
import { ObserverLocator } from 'aurelia-framework';
@inject(ValidationControllerFactory,ObserverLocator)
export class Create{ 
    
    isBroken ="";
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
     
    constructor(validationControllerFactory,observerLocator){
        this.controller = validationControllerFactory.createForCurrentScope();
        var subscription = observerLocator
            .getObserver(this, 'asset')
            .subscribe(this.onAssetChange.bind(this));     

              
    }
    
    submitAsset(){

    }
    onAssetChange(){
        if(this.asset){
            ValidationRules.ensure('name')
            .required().on(this.asset);
        }
    }
}