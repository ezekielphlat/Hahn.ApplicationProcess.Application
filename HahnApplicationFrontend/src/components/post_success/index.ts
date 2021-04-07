import {inject} from 'aurelia-framework';
import {EventAggregator} from 'aurelia-event-aggregator';

@inject(EventAggregator)
export class PostSuccess{
    eventAggregator:any;
    resData: any;
    
 constructor(eventAggregator){
    this.eventAggregator = eventAggregator;
    this.eventAggregator.subscribe('createStatus', payload => {
        this.resData = payload;
        console.log(payload);
     });
 }

}