##	PIS notes
 - koristiti tuple httpwebrequest i errormessage

 // provjera ko u headeru postoji param userId
 ```c#
 bool reqUser = await PickLastRequestUserId();
 if(!reqUser) {
	return BadRequest("message");
 }
 ```