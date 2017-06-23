(function () {
    //Cria um Module 
    // será usado ['ng-Route'] quando implementarmos o roteamento
    angular.module('datepickerapp', ['ngMaterial', 'ngMessages']).controller('AppCtrl', function () {
        this.myDate = new Date();
        this.isOpen = false;
    });
   
})();