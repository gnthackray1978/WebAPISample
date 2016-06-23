// The validateage function
$.validator.addMethod(
    'validateage',
    function (value, element, params) {
        return Date.parse(value) <= Date.parse(params.agerequirementproperty);
    });

$.validator.unobtrusive.adapters.add(
    'validateage', ['agerequirementproperty'], function (options) {
        var params = {            
            agerequirementproperty: options.params.agerequirementproperty
        };
        options.rules['validateage'] = params;
        options.messages['validateage'] = options.message;
    });

$.validator.addMethod(
    'validateillegalchars',
    function (value, element, params) {        
        var s = String(params.illegalcharsproperty);

        var illegalCharList = [];

        for (var i = 0; i < s.length; i++) {            
            if (value.indexOf(s.charAt(i))!==-1) {
                illegalCharList.push(s.charAt(i));
            }

        }

        return illegalCharList.length === 0;
    });

$.validator.unobtrusive.adapters.add(
    'validateillegalchars', ['illegalcharsproperty'], function (options) {
        var params = {
            illegalcharsproperty: options.params.illegalcharsproperty
        };
        options.rules['validateillegalchars'] = params;
        options.messages['validateillegalchars'] = options.message;
    });



