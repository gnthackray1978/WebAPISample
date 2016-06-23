
var UserLib = function () {
    this.LISTUSERS = 'home/ListUsers';
    this.GETUSER = 'home/GetUser';
    this.DELETEUSER = 'home/DeleteUser';
    this.ADDUSER = 'home/AddUser';
};

UserLib.prototype.LoadUserEdittor = function (finished) {
   
    $.post(this.ADDUSER,
      {
          Id: $('#Id').val(),
          FirstName: $('#FirstName').val(),
          LastName: $('#LastName').val(),
          DateOfBirth: $('#DateOfBirth').val()
      },
      function (data) {
          $("#useredit").html(data);

          finished();
      }
      );


};

UserLib.prototype.DeleteUser = function (finished) {

    var id = $('#Id').val();
 
    $.post(this.DELETEUSER,
      {
          userId: id
      },
      function (data) {
          $("#useredit").html(data);

          finished();
      }
      );
};

UserLib.prototype.EditUser = function (id, finished) {
    
    $.get(this.GETUSER,
    {
        userId: id
    },
    function (data) {
        $("#useredit").html(data);
        finished();
    }
    );
};

UserLib.prototype.LoadUserHistory = function (finished) {
   
    $.get(this.LISTUSERS,
        function (data) {
            $("#userhistory").html(data);
            finished();
        }
    );
}

UserLib.prototype.Init = function () {

    var that = this;

    $("#save").off("click");
    $("#new").off("click");
    $("#delete").off("click");
    $(".edituser").off("click");

    $.validator.unobtrusive.parse();
    $.validator.unobtrusive.parse('form');



    $("#save").click(function (e) {
        console.log('save user clicked');
        e.preventDefault();

        if ($("form").valid()) {
            that.LoadUserEdittor(function () {
                that.LoadUserHistory(function() {
                    that.Init();
                });
            });
        }

    });

    $("#new").click(function (e) {
        console.log('new user clicked');
        e.preventDefault();
        $('#Id').val('0');
        $('#FirstName').val('');
        $('#LastName').val('');
        $('#DateOfBirth').val('02/05/1980');
    });


    $("#delete").click(function (e) {
        console.log('delete user clicked');

        e.preventDefault();

        that.DeleteUser(function () {
            that.LoadUserHistory(function() {
                that.Init();
            });
        });

    });

    $(".edituser").click(function (e) {
        console.log('edit user clicked');
        e.preventDefault();
        that.EditUser(this.dataset.id, function() {
            that.Init();
        });
    });

}



$(document).ready(function () {

    var userlib = new UserLib();

    userlib.Init();
});