"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.ListDishesComponent = void 0;
var core_1 = require("@angular/core");
var ListDishesComponent = /** @class */ (function () {
    function ListDishesComponent(dishesService) {
        this.dishesService = dishesService;
        this.dishes = [];
        this.page = 1;
        this.order = false;
        this.isDesc = false;
        this.kindOfName = false;
        this.typeName = false;
        this.productName = false;
    }
    ListDishesComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.dishesService.getDishes().subscribe(function (data) {
            _this.dishes = data;
            console.log(_this.dishes);
            _this.totalLenght = data.length;
        });
    };
    ListDishesComponent.prototype.search = function () {
        var _this = this;
        if (this.dishName == "") {
            this.ngOnInit();
        }
        else {
            this.dishes = this.dishes.filter(function (res) {
                return res.dishName.toLocaleLowerCase().match(_this.dishName.toLocaleLowerCase());
            });
        }
    };
    ListDishesComponent.prototype.sortByNumber = function () {
        if (this.order) {
            var newarr = this.dishes.sort(function (a, b) { return a.size - b.size; });
            this.dishes = newarr;
        }
        else {
            var newarr = this.dishes.sort(function (a, b) { return b.size - a.size; });
            this.dishes = newarr;
        }
        this.order = !this.order;
    };
    ListDishesComponent.prototype.sortByString = function (property) {
        this.isDesc = !this.isDesc;
        var direction = this.isDesc ? 1 : -1;
        this.dishes.sort(function (a, b) {
            if (a[property] < b[property]) {
                return -1 * direction;
            }
            else if (a[property] > b[property]) {
                return 1 * direction;
            }
            else {
                return 0;
            }
        });
    };
    ListDishesComponent.prototype.showKindsOf = function () {
        this.kindOfName = !this.kindOfName;
    };
    ListDishesComponent.prototype.showTypes = function () {
        this.typeName = !this.typeName;
    };
    ListDishesComponent.prototype.showProducts = function () {
        this.productName = !this.productName;
    };
    ListDishesComponent.prototype.deleteDish = function (dishId) {
        var _this = this;
        this.dishesService.deleteDish(dishId).subscribe(function (res) {
            _this.dishes = _this.dishes.filter(function (item) { return item.dishId !== dishId; });
        });
    };
    ListDishesComponent = __decorate([
        (0, core_1.Component)({
            selector: 'app-list',
            templateUrl: './listDishes.component.html',
            styleUrls: ['./listDishes.component.css']
        }),
        (0, core_1.Injectable)({
            providedIn: 'root'
        })
    ], ListDishesComponent);
    return ListDishesComponent;
}());
exports.ListDishesComponent = ListDishesComponent;
//# sourceMappingURL=listDishes.component.js.map