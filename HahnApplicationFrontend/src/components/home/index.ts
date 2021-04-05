import {HttpClient, json} from 'aurelia-fetch-client';
import {DialogService} from 'aurelia-dialog';
import {EditAssetModal} from '../modal/edit_asset'

let httpClient = new HttpClient()
let baseUrl = "https://localhost:5001/api/Asset";

export class Home{
    static inject = [DialogService];
    assetData: any;
    dialogService: any;
    constructor(dialogService){
        this.getAllAssets();
        this.dialogService = dialogService;
      
    }

    openModal(asset) {
        this.dialogService.open( {viewModel: EditAssetModal, model: asset }).whenClosed(response => {
           console.log(response);
              
           if (!response.wasCancelled) {
              console.log(response);
              console.log(asset);
           } else {
              console.log('cancelled');
           }
           console.log(response.output);
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
        console.log(id);
    }
}