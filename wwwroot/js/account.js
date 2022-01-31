(function ($) {

    function accountRegister() {
        $this = this;

        $this.initializeForm = function () {

            var ddlCountry =$('#ddlcountry');
            var ddlState = $('#ddlstate');  
            var ddlCity = $('#ddlcity');  


            $.get("/api/common/countrylist", function (data) {
                $.each(data, function (index, value) {
                    ddlCountry.append('<option value="' + value.value + '">' + value.text + '</option>');
                });
            });


            ddlCountry.on('change', function () {

                $.ajax({
                    url: "/api/common/statelist",
                    type: 'post',
                    dataType: 'json',
                    data: { country_code: $('#ddlcountry').val() },
                    success: function (data) {
                        $.each(data, function (index, value) {
                            ddlState.append('<option value="' + value.value + '">' + value.text + '</option>');
                        });
                    },
                });


            });

            ddlState.on('change', function () {
                
                ddlCity.empty();

                var model = {
                    country_code: $('#ddlcountry').val(),
                    state_code: $(this).val()
                };
                $.ajax({
                    url: "/api/common/citylist",
                    type: 'post',
                    data: model,
                    dataType: 'json',
                    success: function (data) {
                        $.each(data, function (index, value) {
                            ddlCity.append('<option value="' + value.value + '">' + value.text + '</option>');
                        });
                    },
                });
            });



            $('#btnFormSubmit').on('click', function () {
                $.ajax({
                    url: "/api/account/save",
                    type: 'POST',
                    dataType: 'json',
                    data: $('#form_registration').serialize(),
                    success: function (data, textStatus, xhr) {
                        console.log(data);
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        console.log(textStatus);
                    }
                });
            });

        }
    }

    $(function () {
        var account = new accountRegister();
        account.initializeForm();
    })


}(jQuery));