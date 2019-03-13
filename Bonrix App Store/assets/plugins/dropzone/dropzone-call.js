 Dropzone.autoDiscover = false;

   $(document).ready(function () {
        $("#id_dropzone").dropzone({
            maxFiles: 2000,
            url: "/ajax_file_upload_handler/",
            success: function (file, response) {
                console.log(response);
            }
        });
   })