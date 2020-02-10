var globalCounter = 1;
var uniqueId;
$("#file").change(function (e) {
    var count = e.target.files.length;
    $('#images').empty();

    for (let i = 0; i < count; i++) {
        var reader = new FileReader();
        reader.onload = function (e) {
            uniqueId = "image" + globalCounter;

            $('#images').append($('<div>', { id: uniqueId, src: e.target.result, class: 'col-md-4 col-sm-6 col-12 pb-2 my-auto' }));
            let $imageId = $('#' + uniqueId);

            $imageId.prepend($('<img>', { src: e.target.result, class: 'img-fluid' }));

            // $imageId.on('click', function(e)
            // {
            //     console.log(e);
            //     console.log($("#file").files);

            //     $(e.target).remove();
            // });

            $imageId.data('position', i);

            globalCounter++;
        };
        reader.readAsDataURL(e.target.files[i]);
    }
});
