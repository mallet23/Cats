(function($) {

    var catCategories = (function () {

        var getCatImageUrl = '\\cats\\getimagelinkasync';

        function init() {
            var $category = $('#SelectedCategory');

            $category.val('');
            $category.on('change', onCategoryChanged);
        }

        function onCategoryChanged(e) {
            var value = $(e.currentTarget).val();
            var $imagesContainer = $('#CatImages');

            var loadImage = function (imageUrl) {
                $('<img class="cat-image"/>')
                    .on('load', function () {
                        $imagesContainer.append(this);
                    })
                    .on('error', function () {
                        console.log("error loading image:" + imageUrl);
                    })
                    .attr("src", imageUrl);
            }

            $.ajax({
                    type: 'POST',
                    url: getCatImageUrl,
                    data: {
                        category: value
                    },
                    success: function (data) {
                        if (data && data.images && $imagesContainer.length !== 0) {
                            $imagesContainer.empty();

                            data.images.forEach(loadImage);
                        }
                    },
                    function(xhr) {
                        var err = eval("(" + xhr.responseText + ")");
                        alert(err.Message);
                    }
                }
            );
        }

       

        return {
            init: init
        };

    })();

    $(document).ready(function () {
        catCategories.init();
    });

})(jQuery);