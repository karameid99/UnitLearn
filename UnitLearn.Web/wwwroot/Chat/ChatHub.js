
// get message
var userid = document.getElementById("userid").value;
var username = document.getElementById("username").value;
var groupId = document.getElementById("groupId").value;
var chatGroupId;

function sendMessage() {
    // save in database
    var message = document.getElementById("message").value;
    if (message.trim()) {
        firebase.database().ref("messages").push().set({
            "senderId": userid,
            "senderName": username,
            "groupId": chatGroupId,
            "dateTime": new Date().toLocaleString(),
            "message": message
        });
        document.getElementById("message").value = '';
        document.getElementById("messages").innerHTML = '';
        getMessages(chatGroupId);
    }
    // prevent form submitting
    return false;
}

$(document).on("click", ".group-item", function () {
    $(".group-item").each(function () {
        $(this).removeAttr('style');
    });
    $(this).css("color", "red");
    $(this).css("font-weight", "bold");

    chatGroupId = $(this).attr('id');
    document.getElementById("messages").innerHTML = '';
    // listen for incoming messages
    getMessages(chatGroupId);

});

function getMessages(chatGroupId) {
    firebase.database().ref("messages").orderByChild("groupId").equalTo(chatGroupId).on("child_added", function (snapshot) {
        var html = "";
        if (snapshot.val().senderId == userid) {
            html += '<div title="' + snapshot.val().dateTime + '" class="media w-50 ml-auto mb-3" id="message-' + snapshot.key + '">';
            html += '<div class="media-body">';
            html += '<p class="small text-muted" style="margin-bottom: 0rem!important">' + snapshot.val().senderName + '</p>';
            html += '<div class="bg-primary rounded py-2 px-3 mb-2">';
            if (snapshot.val().message.includes("https") || snapshot.val().message.includes("http")) {
                html += '<p class="text-small mb-0 text-white"> ';
                html += "<a style='padding-left:0.5em' title='حذف الرسالة لدى الجميع' class='text-danger' data-id='" + snapshot.key + "' onclick='deleteMessage(this);'>";
                html += "<i class='fa fa-trash' style='color:#ff0000;cursor:pointer'></i></a>";
                html += '<a class="text-white" target="_blank" href="' + snapshot.val().message + '">' + snapshot.val().message + ' </a></p>';
            } else {
                html += '<p class="text-small mb-0 text-white"> ';
                html += "<a style='padding-left:0.5em' title='حذف الرسالة لدى الجميع' class='text-danger' data-id='" + snapshot.key + "' onclick='deleteMessage(this);'>";
                html += "<i class='fa fa-trash' style='color:#ff0000;cursor:pointer'></i></a>";
                html += snapshot.val().message + ' </p>';
            }
            html += '</div>';
            html += '</div>';
            html += '</div>';
        } else {
            html += '<div title="' + snapshot.val().dateTime + '" class="media w-50 mb-3" id="message-' + snapshot.key + '">';
            html += '<div class="media-body ml-3">';
            html += '<p class="small text-muted" style="margin-bottom: 0rem!important">' + snapshot.val().senderName + '</p>';

            html += '<div class="bg-light rounded py-2 px-3 mb-2">';
            if (snapshot.val().message.includes("https") || snapshot.val().message.includes("http")) {
                html += '<p class="text-small mb-0 text-muted"><a class="text-primary" target="_blank" href="' + snapshot.val().message + '">' + snapshot.val().message + '</a></p>';
            } else {
                html += '<p class="text-small mb-0 text-muted">' + snapshot.val().message + '</p>';
            }
            html += '</div>';
            html += '</div>';
            html += '</div>';
        }
        document.getElementById("messages").innerHTML += html;
        $('#messages').scrollTop($('#messages')[0].scrollHeight);
    });
}

function deleteMessage(self) {
    // get message ID
    var messageId = self.getAttribute("data-id");
    // delete message
    firebase.database().ref("messages").child(messageId).remove();
}


// attach listener for delete message
firebase.database().ref("messages").on("child_removed", function (snapshot) {
    // remove message node
    document.getElementById("message-" + snapshot.key).innerHTML = "لقد تم حذف الرسالة";
});



