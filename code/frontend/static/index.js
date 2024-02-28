$(document).ready(function () {

  initToolbar();
  initTabControl();

  $('#generate-response-btn').click(function (e) {
    console.log("called click....");
    e.preventDefault(); // Prevent the default form submission

    // Get the input values
    var prompt = $('#prompt').val();
    var llm = $('#llm').val();

    // Make a POST request to the backend API
    $.ajax({
      url: '/api/generateResponse',
      type: 'POST',
      contentType: 'application/json',
      data: JSON.stringify({ prompt: prompt, llm: llm }),
      success: function (response) {
        // Handle the response from the backend API
        console.log("log:" + response);
        // Perform any desired actions with the response data
      },
      error: function (error) {
        // Handle any errors that occur during the API request
        console.error("error:" + error);
        console.error(JSON.stringify(error))
      }
    });
  });
});

function initTabControl() {
  $('#myTabs a').on('click', function (e) {
    e.preventDefault();
    $(this).tab('show');

    if ($(this).attr('href') === '#dealCapture') {
      $('#selectDiv').show();
    } else {
      $('#selectDiv').hide();
    }
  });
}

function initToolbar() {
  $('.toolbar-icon').click(function() {
    var iconClass = $(this).attr('class').split(' ')[1];
    alert('Icon clicked: ' + iconClass);
  });
}