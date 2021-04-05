import {PLATFORM} from 'aurelia-pal';

require('bootstrap/dist/css/bootstrap.min.css');
require('bootstrap');

export class App {
  router: any;
  configureRouter(config, router){
    config.title = "Hahn Assets";

    config.map([
      {route: ["","home"], name:"home", moduleId: PLATFORM.moduleName("./components/home/index"), nav: true,title:"Home"},
      {route: ["create"], name:"create", moduleId: PLATFORM.moduleName("./components/create/index"), nav: true,  title:"Create Asset"},
    ]);
    this.router = router;
  }
}
