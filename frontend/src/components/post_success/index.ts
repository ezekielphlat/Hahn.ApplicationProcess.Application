import {inject} from 'aurelia-framework';
import {Router} from 'aurelia-router';

@inject(Router)
export class PostSuccess{
    router: any;
    resData: any;
    subscriber: any;
    
 constructor(router){
     this.router = router;
     setTimeout(() => {
        this.router.navigateToRoute('home');
    }, 5000);
 }
}