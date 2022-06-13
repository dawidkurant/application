"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.DishesModule = void 0;
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var dishes_routing_module_1 = require("./dishes-routing.module");
var listDishes_component_1 = require("./list/listDishes.component");
var forms_1 = require("@angular/forms");
var ngx_pagination_1 = require("ngx-pagination");
var DishesModule = /** @class */ (function () {
    function DishesModule() {
    }
    DishesModule = __decorate([
        (0, core_1.NgModule)({
            declarations: [
                listDishes_component_1.ListDishesComponent
            ],
            imports: [
                common_1.CommonModule,
                dishes_routing_module_1.DishesRoutingModule,
                forms_1.FormsModule,
                forms_1.ReactiveFormsModule,
                ngx_pagination_1.NgxPaginationModule
            ]
        })
    ], DishesModule);
    return DishesModule;
}());
exports.DishesModule = DishesModule;
//# sourceMappingURL=dishes.module.js.map