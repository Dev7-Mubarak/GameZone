
$.validator.addMethod('filesize', function (value, element, param) {
    return isValid = this.optional(element) || element.files[0].size < param;
});
