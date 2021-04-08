import {inject} from 'aurelia-framework';
import {view} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';
import {ValidationRules, ValidationControllerFactory} from 'aurelia-validation';
import { ObserverLocator } from 'aurelia-framework';
import {PLATFORM} from 'aurelia-pal';


@view(PLATFORM.moduleName('edit_asset'))
@inject(DialogController, ValidationControllerFactory,ObserverLocator)
export class EditAssetModal{
    controller: any;
    dialogController: any;
    answer : any;
    asset: any;
    departments = [
      { id: 1, name: 'HQ' },
      { id: 2, name: 'Store1' },
      { id: 3, name: 'Store2' },
      { id: 4, name: 'Store3' },
      { id: 5, name: 'MaintenanceStation' },
    ];
    constructor(dialogController, validationControllerFactory, observerLocator) {
        this.controller = validationControllerFactory.createForCurrentScope();
        this.dialogController = dialogController;
        this.answer = null;
  
        dialogController.settings.centerHorizontalOnly = true;
        var subscription = observerLocator
        .getObserver(this, 'asset')
        .subscribe(this.onAssetChange.bind(this));  
     }
     activate(asset) {
        this.asset = asset;
     }
    
     onAssetChange(){
      if(this.asset){
          
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