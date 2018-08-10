// Write your Javascript code.

// Create a "close" button and append it to each list item
var myNodelist = document.querySelectorAll(".main LI");
var i;
for (i = 0; i < myNodelist.length; i++) {
    var span = document.createElement("SPAN");
    var txt = document.createTextNode("\u00D7");
    span.className = "close";
    span.appendChild(txt);
    myNodelist[i].appendChild(span);
}

// Click on a close button to hide the current list item
var close = document.getElementsByClassName("close");
var i;
for (i = 0; i < close.length; i++) {
    close[i].onclick = function () {
        var div = this.parentElement;
        div.style.display = "none";
    }
}

// Add a "checked" symbol when clicking on a list item
var list = document.querySelector('#myUL');
list.addEventListener('click', function (ev) {
    if (ev.target.tagName === 'LI') {
        ev.target.classList.toggle('checked');
    }
}, false);

// Create a new list item when clicking on the "Add" button
function newElement() {
    var li = document.createElement("li");
    var inputValue = document.getElementById("myInput").value;
    var t = document.createTextNode(inputValue);
    li.appendChild(t);
    if (inputValue === '') {
        alert("You must write something!");
    } else {
        document.getElementById("myUL").appendChild(li);
        //after add here!!! call api to server!!!
        var item = {
            "name": "San pham 5",
            "description": "thong tin chi tiet",
            "price": 65,
            "pictureFileName": "a5.png",
            "pictureUri": "http://abc.com/a5"
        };
        insertItem(item);
    }
    document.getElementById("myInput").value = "";

    var span = document.createElement("SPAN");
    var txt = document.createTextNode("\u00D7");
    span.className = "close";
    span.appendChild(txt);
    li.appendChild(span);

    for (i = 0; i < close.length; i++) {
        close[i].onclick = function () {            
            var div = this.parentElement;
            div.style.display = "none";
            //after delete here!!! call api to server!!!
            var id = 5;
            deleteItem(id);
        }
    }
}

//===========================================
// MYCODE
//===========================================
var apiUrl = 'https://l7rwbbv308.execute-api.us-west-2.amazonaws.com/Prod/api/catalog-items';

function insertItem(item) {    
    $.ajax({
        url: apiUrl,
        method: 'POST',        
        dataType: 'json',
        data: JSON.stringify(item),
        success: function (resp) {
            console.log('API - insert has been sent and success');
        },
        error: function (req, status, err) {
            console.log('something went wrong', status, err);
        }
    });
}

function deleteItem(id) {    
    $.ajax({
        url: apiUrl + '/' + id,
        method: 'DELETE',        
        success: function (resp) {
            console.log('API - delete has been sent and success');
        },
        error: function (req, status, err) {
            console.log('something went wrong', status, err);
        }
    });
}



