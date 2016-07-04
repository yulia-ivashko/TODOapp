function SomeMethod(checkboxInput) {
    $.ajax({
        type: 'POST',
        url: Tasks / Edit,
        data: { newValue: checkboxInput.checked },
        success: success,
        dataType: 'json'
    });
}