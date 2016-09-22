var config_module = angular.module('empower', []);

var config_data_development = {
    'Application_Settings': {
        'App_Name': 'Empower',
        'App_Desc': 'Employee Management'
    },

    'Development_Settings': {
        'employeeService': 'http://INMUMWRK000086/WebAPI/api/Products/'
    },

    'Production_Settings': {
        'employeeService': 'http://admin-pc/WebAPI/api/Employees/'
    }
}

angular.forEach(config_data_development, function (key, value) {
    config_module.constant(value, key);
});