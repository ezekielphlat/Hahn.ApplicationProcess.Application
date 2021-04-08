import {inject} from 'aurelia-framework';
import {DialogController} from 'aurelia-dialog';

@inject(DialogController)
export class Prompt {
    controller: any;
    answer: any;
    message:any;
    asset: any;
    constructor(controller) {
       this.controller = controller;
       this.answer = null;
 
       controller.settings.centerHorizontalOnly = true;
    }
    activate(asset) {
       this.asset = asset;
    }
 }