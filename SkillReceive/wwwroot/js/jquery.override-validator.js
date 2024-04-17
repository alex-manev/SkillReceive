jQuery(function ($)
{
	$.validator.addMethod('number', function (valur, element) {
		return this.optional(element) || /^-?(?:(\.|,)\d+)?$/.test(value);
	});
});
