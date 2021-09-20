var routeUrl = location.protocol + "//" + location.host;

$(document).ready(function ()
{
    $("#appointmentDate").kendoDateTimePicker(
        {
            value: new Date(),
            dateInput: false
        })
    InitializeCalendar();
});

function InitializeCalendar(){
    try{
        
            var calendarEl = document.getElementById('calendar');
            if(calendarEl != null){
            var calendar = new FullCalendar.Calendar(calendarEl, {
              initialView: 'dayGridMonth',
              headerToolbar:
              {
                  left: 'prev,next,today',
                  center: 'title',
                  right: 'dayGridMonth,timeGridWeek,timeGridDay'
              },
              selectable:true,
              editable:false,
              select: function(event)
              {
                  onShowModal(event, null);
              }
            });
            calendar.render();
        }
    }
    catch(e){
        alert(e);
    }
}

function onShowModal(obj, IsEventDetail) 
{
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function OnSubmitForm() {
    if (checkValidations()) {
        var requestData =
        {
            Id: parseInt($("#id").val()),
            Title: $("#title").val(),
            Description: $("#description").val(),
            StartDate: $("#appointmentDate").val(),
            Duration: $("#duration").val(),
            DoctorId: $("#doctorId").val(),
            PatientId: $("#patientId").val()
        };

        $.ajax({
            url: routeUrl + '/api/Appointment/SaveCalendarData',
            type: 'POST',
            data: JSON.stringify(requestData),
            contentType: 'application/json',
            success: function (response) {
                if (response.status === 1) {
                    $.notify(response.message, "success");
                    onCloseModal();
                }
                else {
                    $.notify(response.message, "error");
                }
            },
            error: function (xhr) {
                $.notify("Error", "error");
            }

        })
    }

    function checkValidations() {
        var IsValid = true;
        if ($("#title").val() === undefined || $("#title").val() === "") {
            IsValid = false;
            $("#title").addClass('error');
        }
        else {
            $("title").removeClass('error');
        }

        if ($("#appointmentDate").val() === undefined || $("#appointmentDate").val() === "") {
            IsValid = false;
            $("#appointmentDate").addClass('error');
        }
        else {
            $("appointmentDate").removeClass('error');
        }

        return IsValid;

    }

}