"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.DishesRoutingModule = void 0;
var core_1 = require("@angular/core");
var router_1 = require("@angular/router");
var listDishes_component_1 = require("./list/listDishes.component");
var auth_guard_service_1 = require("../services/auth-guard.service");
var routes = [
    { path: 'dishes', redirectTo: 'dishes/list', pathMatch: 'full' },
    { path: 'dishes/list', component: listDishes_component_1.ListDishesComponent }
];
var DishesRoutingModule = /** @class */ (function () {
    function DishesRoutingModule() {
    }
    DishesRoutingModule = __decorate([
        (0, core_1.NgModule)({
            imports: [router_1.RouterModule.forChild(routes)],
            providers: [auth_guard_service_1.AuthGuardService],
            exports: [router_1.RouterModule]
        })
    ], DishesRoutingModule);
    return DishesRoutingModule;
}());
exports.DishesRoutingModule = DishesRoutingModule;
//# sourceMappingURL=dishes-routing.module.js.map