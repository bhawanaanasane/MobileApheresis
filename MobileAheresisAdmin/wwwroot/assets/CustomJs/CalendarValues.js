function AddEvents(List) {
   
    $('#calendar').fullCalendar('removeEvents');
   $('#calendar').fullCalendar('renderEvents', List);

        //$("#ProductName_0").append(
        //    $('<option></option>').val(item.value).html(item.text + " ( " + item.Column2 + " )"));
    //});

}

function AddEventsMonthwise(List) {

    var List2 = JSON.parse(List);
    $('#calendar').fullCalendar('removeEvents');
    $('#calendar').fullCalendar('renderEvents', List2);

    //$("#ProductName_0").append(
    //    $('<option></option>').val(item.value).html(item.text + " ( " + item.Column2 + " )"));
    //});

}

