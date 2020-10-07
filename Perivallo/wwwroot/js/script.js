
$(window).on('load', function () {
    $('.pageloader').remove();
    if ($('#regError').val() == 1) {
        $('#step-dot-2').click();
    }
});

$(document).ready(function () {
    // navbar stuff

    let activeNow = $('.active-nav-item');

    var tlm = new TimelineMax({ paused: true });
    tlm.to(".collapse-icon", { duration: 0.5, rotation: 90 });

    $('.nav-res-btn').click(function (e) {
        if ($(this).hasClass("unclickable")) {
            e.preventDefault();
        }
        else {
            $('.nav-res-btn').addClass("unclickable");
            if (tlm.progress() === 0) {
                tlm.play();
            }
            if (tlm.progress() === 1) {
                tlm.reverse();
            }
            $('.navigation').stop(true, true).slideToggle();
            setTimeout(function () {
                $('.nav-res-btn').removeClass("unclickable");
            }, 500);
        }
    });

    $(window).on('resize', function () {
        var win = $(this);
        if (win.width() > 500) {
            $('.navigation').css("display", "flex")
            if (tlm.progress() === 1) {
                tlm.reverse();
            }
        }
        else {
            $('.navigation,.notification-dropdown,.triangle').css("display", "none");
            if ($('.notification').parent().hasClass('active-nav-item')) {
                $('.notification').parent().removeClass('active-nav-item');
                activeNow.addClass('active-nav-item');
            }
        }
    });

    // $('.search-bar .search-field-wrapper .search-results-list .search-results-item .result-wrapper .text .name').each(function(){
    //     if($(this).text().length>28){
    //         $(this).text($(this).text().substr(0,25)+"...");
    //     }
    // });

    $('#nav-search').next().css('border-width', '0px');
    $('#nav-search').keyup(function () {
        if ($(this).val().length > 0) {
            $('.clear-icon').fadeIn(100);
        }
        else {
            $('.clear-icon').fadeOut(100);
        }
        let field = $(this);
        let term = field.val();
        if (term == "") {
            field.next().empty();
            field.next().css('border-width', '0px');
        }
        if (term.length > 0) {
            $.ajax({
                url: "/Home/Search?term=" + term,
                type: "Get",
                cache: true,
                success: function (response) {
                    if (response.trim() != "") {
                        field.next().css('border-width', '1px');
                    }
                    else {
                        field.next().css('border-width', '0px');
                    }
                    field.next().empty();
                    field.next().append(response);
                }
            });
        }
    });

    $('#nav-search').focus(function () {
        if ($('.notification').parent().hasClass('active-nav-item')) {
            $('.notification-dropdown, .triangle').hide();
            $('.notification').parent().removeClass('active-nav-item');
            activeNow.addClass('active-nav-item');
        }
    });

    $('#nav-search').keypress(function () {
        if ($(this).val().length > 0) {
            $('.clear-icon').fadeIn(100);
        }
        else {
            $('.clear-icon').fadeOut(100);
        }
    });

    $('.clear-icon').click(function () {
        $('#nav-search').val("");
        $('#nav-search').focusout();
        $('#nav-search').next().empty();
        $('#nav-search').next().css('border-width', '0px');
        $(this).fadeOut(100);
    });

    let tll = new TimelineLite({
        paused: true
    });

    tll.from(".see-all-icon", { duration: 0.2, x: -8, opacity: 0 });

    $('.see-all').hover(function () {
        tll.play();
    }, function () {
        tll.reverse();
    });

    $('.notification').click(function (e) {
        if ($(window).width() > 500) {
            e.preventDefault();
            let parent = $(this).parent();
            if (!parent.hasClass('active-nav-item')) {
                activeNow.removeClass('active-nav-item');
                parent.addClass('active-nav-item');
                $('.notification-dropdown, .triangle').show();
            }
            else {
                activeNow.addClass('active-nav-item');
                parent.removeClass('active-nav-item');
                $('.notification-dropdown, .triangle').hide();
            }
        }
    });

    // main part

    // publish

    $('#publish').keyup(function () {
        if ($(this).val().trim() == "") {
            if ($('#publish-input').val() == "" && $('#link').val().trim() == "") {
                $('.publish-button').attr("disabled", true);
                $('.publish-button').css('opacity', '0.4');
            }
        }
        else {
            $('.publish-button').removeAttr("disabled");
            $('.publish-button').css('opacity', '1');
        }
    });

    $('#link').keyup(function () {
        if ($(this).val().trim() == "") {
            if ($('#publish-input').val() == "" && $('#publish').val().trim() == "") {
                $('.publish-button').attr("disabled", true);
                $('.publish-button').css('opacity', '0.4');
            }
        }
        else {
            $('.publish-button').removeAttr("disabled");
            $('.publish-button').css('opacity', '1');
        }
    });

    $('#publish').focus(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper').show();
        $('.app-overlay').addClass('overlay-active');
    });

    $('.compose-option').click(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper').show();
        $('.app-overlay').addClass('overlay-active');
    });

    $('.location-option').click(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper,.location-suboption').show();
        $('.app-overlay').addClass('overlay-active');
    });

    $('.location-suboption .location-wrapper .close-icon').click(function () {
        $('.location-suboption').hide();
    });

    $('.link-option').click(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper,.link-suboption').show();
        $('.app-overlay').addClass('overlay-active');
    });

    $('.link-suboption .link-wrapper .close-icon').click(function () {
        $('.link-suboption').hide();
    });

    $('.tag-option').click(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper,.tag-suboption').show();
        $('.app-overlay').addClass('overlay-active');
        $('.js-example-basic-multiple').select2({
            placeholder: '@ Tag your friends'
        });
    });

    $('.tag-suboption .tag-wrapper .close-icon').click(function () {
        $('.tag-suboption').hide();
    });

    $('.close-publish').click(function () {
        $('.close-publish,.hidden-preview,.publish-wrapper,.location-suboption,.link-suboption,.tag-suboption').hide();
        $('.app-overlay').removeClass('overlay-active');
    });

    $('.publish-owl-carousel').owlCarousel({
        items: 1,
        dots: true
    });

    $('#publish-input').change(function (ev) {
        let owlLength = $('.publish-owl-carousel .item').length;
        for (let i = 0; i < owlLength; i++) {
            $(".publish-owl-carousel").trigger('remove.owl.carousel', [i]).trigger('refresh.owl.carousel');
        }
        upload(ev.target.files);
        if ($(this).val() != "") {
            $('.preview-wrapper h6').hide();
            $('.hidden-preview .publish-remove').show();
            $('.publish-button').removeAttr("disabled");
            $('.publish-button').css('opacity', '1');
        }
        else {
            $('.preview-wrapper').show();
        }
    });

    $('.hidden-preview .publish-remove').click(function () {
        $('#publish-input').val("");
        if ($('#publish').val() != "" || $('#link').val() != "") {
            $('.publish-button').removeAttr("disabled");
            $('.publish-button').css('opacity', '1');
        }
        if ($('#publish').val() == "" && $('#link').val() == "") {
            $('.publish-button').attr("disabled", true);
            $('.publish-button').css('opacity', '0.4');
        }
        let owlLength = $('.publish-owl-carousel .item').length;
        for (let i = 0; i < owlLength; i++) {
            $(".publish-owl-carousel").trigger('remove.owl.carousel', [i]).trigger('refresh.owl.carousel');
        }
        $(this).hide();
        $('.preview-wrapper h6').show();
    });

    function upload(files) {
        for (let file of files) {
            let reader = new FileReader();
            reader.onloadend = function (ev) {
                let owlItem = $("<div>").addClass('item');
                let imgPreview = $("<div>").addClass('image-preview');
                let img = $("<img>").attr("src", ev.target.result);
                imgPreview.append(img);
                owlItem.append(imgPreview);
                $('.publish-owl-carousel').trigger('add.owl.carousel', [owlItem]).trigger('refresh.owl.carousel');
            }
            reader.readAsDataURL(file);
        }
    }

    // posts

    $('.prelike').click(function () {
        let likebtn = $(this);
        let likedPostId = likebtn.data('postid');
        $.ajax({
            url: "/Home/PostLike?id=" + likedPostId,
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    likebtn.next().show();
                    likebtn.hide();
                    likebtn.parent().parent().next().children().eq(0).children().eq(0).children().eq(1).text(response);
                }
            }
        });
    });

    $('.liked').click(function () {
        let dislikebtn = $(this);
        let dislikedPostId = dislikebtn.data('postid');
        $.ajax({
            url: "/Home/PostDislike?id=" + dislikedPostId,
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != -1) {
                    dislikebtn.prev().show();
                    dislikebtn.hide();
                    dislikebtn.parent().parent().next().children().eq(0).children().eq(0).children().eq(1).text(response);
                }
            }
        });
    });

    $('.prebookmark').click(function () {
        let savebtn = $(this);
        let savedPostId = savebtn.data('postid');
        $.ajax({
            url: "/Home/SavePost?id=" + savedPostId,
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    savebtn.next().show();
                    savebtn.hide();
                }
            }
        });
    });

    $('.bookmarked').click(function () {
        let unsavebtn = $(this);
        let unsavedPostId = unsavebtn.data('postid');
        $.ajax({
            url: "/Home/UnsavePost?id=" + unsavedPostId,
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    unsavebtn.prev().show();
                    unsavebtn.hide();
                }
            }
        });
    });

    $('.post-owl-carousel').owlCarousel({
        items: 1,
        dots: true
    });

    // login

    $('#login-password-input').keyup(function () {
        if ($(this).val().length > 0) {
            if ($(this).attr('type') == 'password') {
                $('.vision-icon').fadeIn(100);
            }
            else {
                $('.vision-on-icon').fadeIn(100);
            }
        }
        else {
            $('.vision-icon,.vision-on-icon').fadeOut(100);
        }
    });

    $('#login-password-input').keypress(function () {
        if ($(this).val().length > 0) {
            if ($(this).attr('type') == 'password') {
                $('.vision-icon').fadeIn(100);
            }
            else {
                $('.vision-on-icon').fadeIn(100);
            }
        }
        else {
            $('.vision-icon,.vision-on-icon').fadeOut(100);
        }
    });

    $('.vision-icon').click(function () {
        $(this).hide();
        $('.locked-icon').hide();
        $('.vision-on-icon, .unlocked-icon').show();
        $('#login-password-input').prop('type', 'text');
    });

    $('.vision-on-icon').click(function () {
        $(this).hide();
        $('.unlocked-icon').hide();
        $('.vision-icon, .locked-icon').show();
        $('#login-password-input').prop('type', 'password');
    });

    // register

    $('.progress-wrap .dot').on('click', function () {
        var $this = $(this);
        var stepValue = $this.attr('data-step');
        $this.closest('.progress-wrap').find('.bar').css('width', stepValue + '%');
        $this.siblings('.dot').removeClass('is-current');
        $this.addClass('is-active is-current');
        $this.prevAll('.dot').addClass('is-active');
        $this.nextAll('.dot').removeClass('is-active');
        $('.process-panel-wrap').removeClass('is-active');
        $('.step-title').removeClass('is-active');

        if (stepValue == '0') {
            $('#signup-panel-1, #step-title-1').addClass('is-active');
        } else if (stepValue == '100') {
            $('#signup-panel-2, #step-title-2').addClass('is-active');
        }
    });

    $('.process-button').on('click', function () {
        var $this = $(this);
        var targetStepDot = $this.attr('data-step');
        $('#' + targetStepDot).trigger('click');
    });

    $('#reg-password-input').keyup(function () {
        if ($(this).val().length > 0) {
            if ($(this).attr('type') == 'password') {
                $('.reg-vision-icon').fadeIn(100);
            }
            else {
                $('.reg-vision-on-icon').fadeIn(100);
            }
        }
        else {
            $('.reg-vision-icon,.reg-vision-on-icon').fadeOut(100);
        }
    });

    $('#reg-password-input').keypress(function () {
        if ($(this).val().length > 0) {
            if ($(this).attr('type') == 'password') {
                $('.reg-vision-icon').fadeIn(100);
            }
            else {
                $('.reg-vision-on-icon').fadeIn(100);
            }
        }
        else {
            $('.reg-vision-icon,.reg-vision-on-icon').fadeOut(100);
        }
    });

    $('.reg-vision-icon').click(function () {
        $(this).hide();
        $('.reg-vision-on-icon').show();
        $('#reg-password-input').prop('type', 'text');
    });

    $('.reg-vision-on-icon').click(function () {
        $(this).hide();
        $('.reg-vision-icon').show();
        $('#reg-password-input').prop('type', 'password');
    });

    $('#reg-confirm-pass,#set-confirm-pass').on("cut copy paste", function (e) {
        e.preventDefault();
    });

    // profile

    $('.pd-collapse-button').click(function () {
        $(this).next().toggleClass('pd-menu-active');
    });

    $('.post-dropdown .button').click(function () {
        $(this).next().toggleClass('post-dropdown-active');
    });

    $('.profile-dropdown .profile-dropdown-button').click(function () {
        $(this).next().toggleClass('profile-dropdown-active');
    });

    $('.comment-dropdown .comment-dropdown-button').click(function () {
        $(this).next().toggleClass('comment-dropdown-active');
    });

    // modals

    $('#comment-modal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let commentId = button.data('commentid');
        let modal = $(this);
        modal.find('input').val("");
        modal.find('.cm-send').val(commentId);
    });

    $('#post-modal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let postId = button.data('postid');
        let modal = $(this);
        modal.find('input').val("");
        modal.find('.pm-send').val(postId);
    });

    $('#user-modal').on('show.bs.modal', function (event) {
        let button = $(event.relatedTarget);
        let userId = button.data('userid');
        let modal = $(this);
        modal.find('input').val("");
        modal.find('.um-send').val(userId);
    });

    // settings

    $('.cover-upload-trigger').click(function () {
        $('#cover-input').click();
    });

    $('#cover-input').change(function (ev) {
        coverUpload(ev.target.files);
        $('#cover-modal').modal('hide');
    });

    function coverUpload(files) {
        for (let file of files) {
            let reader = new FileReader();
            reader.onloadend = function (ev) {
                let img = $("<img>").attr("src", ev.target.result);
                $('.settings-form-wrapper .profile-preview .profile-cover-wrapper').empty();
                $('.settings-form-wrapper .profile-preview .profile-cover-wrapper').append(img);
            }
            reader.readAsDataURL(file);
        }
    }

    $('.avatar-upload-trigger').click(function () {
        $('#avatar-input').click();
    });

    $('#avatar-input').change(function (ev) {
        avatarUpload(ev.target.files);
        $('#avatar-modal').modal('hide');
    });

    function avatarUpload(files) {
        for (let file of files) {
            let reader = new FileReader();
            reader.onloadend = function (ev) {
                let img = $("<img>").attr("src", ev.target.result);
                $('.settings-form-wrapper .profile-preview .avatar-wrapper').empty();
                $('.settings-form-wrapper .profile-preview .avatar-wrapper').append(img);
            }
            reader.readAsDataURL(file);
        }
    }

    // chat

    $('#chat-input').keyup(function () {
        if ($(this).val() == "") {
            $('.message-send-button-wrapper').hide();
        }
        else {
            $('.message-send-button-wrapper').show();
        }
    });

    // comments

    $('#comment-publish').keyup(function () {
        if ($(this).val().trim() == "") {
            $('.comment-post-button').attr("disabled", true);
            $('.comment-post-button').css('opacity', '0.4');
        }
        else {
            $('.comment-post-button').removeAttr("disabled");
            $('.comment-post-button').css('opacity', '1');
        }
    });

    $('.comment-action').click(function () {
        if ($(this).hasClass('like') && !$(this).hasClass('like-active')) {
            let cmtlikebtn = $(this);
            let likedCommentId = cmtlikebtn.data('commentid');
            $.ajax({
                url: "/Post/CommentLike?id=" + likedCommentId,
                type: "Get",
                cache: true,
                success: function (response) {
                    if (response != 0) {
                        cmtlikebtn.addClass('like-active');
                        cmtlikebtn.parent().prev().children().eq(0).children().eq(1).text(response);
                    }
                }
            });
        }
        else if ($(this).hasClass('like') && $(this).hasClass('like-active')) {
            let cmtdislikebtn = $(this);
            let dislikedCommentId = cmtdislikebtn.data('commentid');
            $.ajax({
                url: "/Post/CommentDislike?id=" + dislikedCommentId,
                type: "Get",
                cache: true,
                success: function (response) {
                    if (response != -1) {
                        cmtdislikebtn.removeClass('like-active');
                        cmtdislikebtn.parent().prev().children().eq(0).children().eq(1).text(response);
                    }
                }
            });
            
        }
    });

    $('.pm-send').click(function () {
        let prBtn = $(this);
        let repPostId = prBtn.val();
        let reason = prBtn.parent().prev().children().eq(0).children().eq(0).children().eq(0).children().eq(0).children().eq(0).val();
        $.ajax({
            data: { id: repPostId, text: reason },
            url: "/Home/ReportPost",
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    $('#post-modal').modal('hide');
                }
            }
        });
    });

    $('.cm-send').click(function () {
        let crBtn = $(this);
        let repCommentId = crBtn.val();
        let reason = crBtn.parent().prev().children().eq(0).children().eq(0).children().eq(0).children().eq(0).children().eq(0).val();
        $.ajax({
            data: { id: repCommentId, text: reason },
            url: "/Home/ReportComment",
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    $('#comment-modal').modal('hide');
                }
            }
        });
    });

    $('.um-send').click(function () {
        let urBtn = $(this);
        let repUserId = urBtn.val();
        let reason = urBtn.parent().prev().children().eq(0).children().eq(0).children().eq(0).children().eq(0).children().eq(0).val();
        $.ajax({
            data: { id: repUserId, text: reason },
            url: "/Home/ReportUser",
            type: "Get",
            cache: true,
            success: function (response) {
                if (response != 0) {
                    $('#user-modal').modal('hide');
                }
            }
        });
    });

    let feedPostSkip = 10;
    let feedPostCount = $("#fp-count").val();

    $("#fp-load").click(function () {
        $.ajax({
            url: "/Home/Load?skip=" + feedPostSkip,
            type: "Get",
            success: function (response) {
                let previous_height = $(window).scrollTop();
                $(".feed-posts-wrapper").append(response);
                $(window).scrollTop(previous_height);
                
                $('.post-owl-carousel').owlCarousel({
                    items: 1,
                    dots: true
                });
                feedPostSkip += 10;
                if (feedPostSkip >= feedPostCount) {
                    $("#fp-load").remove();
                }
                
            }
        });
    });

});