(function ($) {
    jQuery.validator.addMethod("porlomenosuncheckbox", function (value, element, params) {
        var retVal = false;

        if ($(element)) {
            retVal = $(element).is(":checked");
        }
        if (retVal == true) {
            return retVal;
        }
        if (params.otherproperty0) {
            if ($('#' + params.otherproperty0)) {
                retVal = $('#' + params.otherproperty0).is(":checked");
            }
        }
        if (retVal == true) {
            return retVal;
        }
        if (params.otherproperty1) {
            if ($('#' + params.otherproperty1)) {
                retVal = $('#' + params.otherproperty1).is(":checked");
            }
        }
        if (retVal == true) {
            return retVal;
        }
        return false;
    });
    jQuery.validator.unobtrusive.adapters.add("porlomenosuncheckbox", ['otherproperty0', 'otherproperty1'],
            function (options) {
                options.rules['porlomenosuncheckbox'] = {
                    other: options.params.other,
                    otherproperty0: options.params.otherproperty0,
                    otherproperty1: options.params.otherproperty1
                };
                options.messages['porlomenosuncheckbox'] = options.message;
            }
        );

    jQuery.validator.addMethod("montototaligualamontofactura", function (value, element, params) {
        var $otraPropiedad = $("#" + params);
        var valorOtraPropiedad = $otraPropiedad.val();

        if (valorOtraPropiedad != $(element).val())
            return false;
        else
            return true;
    });

    jQuery.validator.unobtrusive.adapters.addSingleVal("montototaligualamontofactura", "otra");

    jQuery.validator.addMethod("requiredif", function (value, element, params) {
        if ($(element).val() != '') return true

        var $other = $('#' + params.otro);

        var otherVal = ($other.attr('type').toUpperCase() == "CHECKBOX") ? ($other.attr("checked") ? "true" : "false") : $other.val();

        return params.comp == 'isequalto' ? (otherVal != params.value) : (otherVal == params.value);
    });

    jQuery.validator.unobtrusive.adapters.add("requiredif", ["otro", "comp", "value"],
      function (options) {
          options.rules['requiredif'] = {
              other: options.params.otro,
              comp: options.params.comp,
              value: options.params.value
          };
          options.messages['requiredif'] = options.message;
      }
    );
}(jQuery));
