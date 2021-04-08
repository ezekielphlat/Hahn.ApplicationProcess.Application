import {PLATFORM} from 'aurelia-pal';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');
require('jquery');

export class App {  
  
  router: any;
  i18n: any;
 
  configureRouter(config, router){
    config.title = "Hahn Assets";

    config.map([
      {route: ["","home"], name:"home", moduleId: PLATFORM.moduleName("./components/home/index"), nav: true,title:"Home"},
      {route: "create", name:"create", moduleId: PLATFORM.moduleName("./components/create/index"), nav: true,  title:"Create Asset"},
      {route: "post-success", name:"post-success", moduleId: PLATFORM.moduleName("./components/post_success/index"), nav: false,  title:"Post Success"},
    ]);
    this.router = router;
  }

  setLocale(locale){
    this.i18n.setLocale(locale);
  }
}
