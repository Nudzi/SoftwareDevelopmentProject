function FixOption() {
    console.log("<-------------------------------------->");
    var option = $("#CountryId option:first")[0];
    console.log(option);
    if (option.value == "0")
        option.hidden = true;

    option = $("#CityId option:first")[0];
    console.log(option);
    if (option.value == "0")
        option.hidden = true;
    console.log("<-------------------------------------->");

}

$(document).ready(FixOption);

function GetCitiesByCountryId() {
    var url = "/Address/GetCitiesByCountryId";
    var id = $("#CountryId")[0].value;
    var city = $("#CityId");
    var option;

    if (id == "0") {
        city.empty();

        option = document.createElement("option");
        option.text = "Choose City";
        option.value = "0";
        option.disabled = true;
        option.hidden = true;
        option.defaultSelected = true;

        city.append(option, null);
    }
    else
        $.getJSON(url, { id: id }, function (data) {
            console.log(city);
            city.empty();
            console.log(city);

            $.each(data, function (i, row) {
                console.log(data);
                option = document.createElement("option");

                option.text = row.text;
                option.value = row.value;
                if (row.disabled) {
                    option.disabled = true;
                    option.hidden = true;
                    option.defaultSelected = true;
                }
                console.log(option);

                city.append(option, null);
            });
            FixOption();
        });
}

$("#CountryId").change(GetCitiesByCountryId);
