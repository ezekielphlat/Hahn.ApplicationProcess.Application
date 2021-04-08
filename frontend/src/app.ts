import {PLATFORM} from 'aurelia-pal';
import {I18N} from 'aurelia-i18n';
require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');
require('jquery');

export class App {
  static inject = [I18N];
  
  router: any;
  i18n: any;
  constructor(i18n){
    this.i18n = i18n;    
  }
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
