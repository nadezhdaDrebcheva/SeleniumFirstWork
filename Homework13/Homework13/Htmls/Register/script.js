class Employee {
    constructor(firstName, lastName, gender, technologies, job) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.gender = gender;
        this.technologies = technologies;
        this.job = job;
    }
}

function getEmployeeData() {
    var firstName = document.getElementById('fname').value;
    var lastName = document.getElementById('lname').value;

    var radioButtons = document.getElementsByName('gender');
    var gender = radioButtons[0].checked ? radioButtons[0].value : radioButtons[1].value;

    var technologies = document.getElementsByName('checkBox');
    var techArray = [];
    for (var technology of technologies) {
        if (technology.checked) {
            techArray.push(technology.value);
        }
    }

    var job = document.getElementById('job').value;

    var employeeData = new Employee(firstName, lastName, gender, techArray, job);
    return employeeData;
}

function submitData() {
    var employeeData = getEmployeeData();
    document.getElementById('register').remove();
    alert('Successfully registered an user!');
    appendData(employeeData);
}

function appendData(employeeData) {
    appendParagraph('Name: ' + employeeData.firstName + ' ' + employeeData.lastName + ', Gender:' + employeeData.gender);

    if (employeeData.technologies.length > 0) {
        appendParagraph('Favourite technologies: ' + employeeData.technologies);
    }
    else {
        appendParagraph('No favourite technologies');
    }

    appendParagraph('Currently working as ' + employeeData.job);
}

function appendParagraph(text) {
    var p = document.createElement('p');
    var text = document.createTextNode(text);
    p.appendChild(text);
    document.body.appendChild(p);
}

function disableButton(button) {
    button.setAttribute('disabled', '');
    button.classList.add('disabled-button');
}

function enableButton(button) {
    button.removeAttribute('disabled');
    button.classList.remove('disabled-button');
    button.classList.add('enabled-button');
}

function setTooltipText(text) {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.innerHTML = '';
    tooltip.appendChild(document.createTextNode(text));
}

function manageRegisterButton() {
    var registerButton = document.getElementById('submit');
    var contextMenuRegisterButton = document.getElementById('contextRegister');
    var clearButton = document.getElementById('clear');
    var contextMenuClearButton = document.getElementById('contextClear');

    var firstName = document.getElementById('fname').value;
    var lastName = document.getElementById('lname').value;

    if (firstName == '' || lastName == '') {
        disableButton(registerButton);
        disableButton(contextMenuRegisterButton);
        setTooltipText('Enter First name and Last name to enable Register button.');

        if (firstName != '' || lastName != '') {
            enableButton(clearButton);
            enableButton(contextMenuClearButton);
        }
        else {
            disableButton(clearButton);
            disableButton(contextMenuClearButton);
        }
    }
    else {
        enableButton(registerButton);
        enableButton(contextMenuRegisterButton);
        setTooltipText('Click Register button to submit data.');
        enableButton(clearButton);
        enableButton(contextMenuClearButton);
    }
}

function showTooltip() {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.style.visibility = 'visible';
}

function hideTooltip() {
    var tooltip = document.getElementsByClassName('tooltiptext')[0];
    tooltip.style.visibility = 'hidden';
}


function clearData() {
    window.location.reload();
}

function showInfo() {
    alert('That is a register form. Provide user details to register a new employee.')
}

document.onclick = hideMenu;
document.oncontextmenu = rightClick; 


function hideMenu() {
    var menu = document.getElementById("contextMenu");
    if (menu != null) {
        menu.style.display = "none";
    }
}

function rightClick(e) {
    e.preventDefault();

    if (document.getElementById("contextMenu").style.display == 'block') {
        hideMenu();
    } else {
        var menu = document.getElementById("contextMenu")
        menu.style.display = 'block';
        menu.style.left = e.pageX + "px";
        menu.style.top = e.pageY + "px";
    }
} 