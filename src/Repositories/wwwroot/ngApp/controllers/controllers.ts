namespace Repositories.Controllers {

    export class HomeController {
        public employees;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService) {
            $http.get('api/employees').then((res) => {
                this.employees = res.data;
            });
        }

        public addEmployee(emp) {
            this.$http.post('api/employees', emp).then((res) => {
                this.$state.reload();
            });
        }
    }

    export class DetailsController {
        public employee;
        public edit;

        constructor(public $http: ng.IHttpService, public $state: ng.ui.IStateService, public $stateParams: ng.ui.IStateParamsService) {
            this.edit = false;

            $http.get(`api/employees/${$stateParams['id']}`).then((res) => {
                this.employee = res.data;
            });
        }

        public editEmployee() {
            this.$http.put(`api/employees/${this.employee.id}`, this.employee).then((res) => {
                this.$state.reload();
            });
        }

        public delete() {
            this.$http.delete(`api/employees/${this.employee.id}`).then((res) => {
                this.$state.go('home');
            });
        }
    }



    export class AboutController {
        public message = 'Hello from the about page!';
    }

}
