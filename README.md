<h1> Basora </h1>
<p>Web application for borrowing books. Created with ASP.NET Core 6.0, using the Entity framework core</p>
<h2>
Roles</h2>
<p>Owner - block SuperUsers </p>
<p>SuperUser -  can do everything (edit languages, authors, user informations), except blocking other SuperUsers</p>
<p>Technic - can delete and edit books, block users</p>
<p>User - can borrow and rent books</p>
<p>Loaner - rent books</p>
<p>Reader - borrow books</p>
<p>Handled by claims</p>
<h2>
Verification</h2>
<p>any user can request verification on the verification page by sending a photo of themselves and a photo of their ID card. SuperUser will review and approve this request</p>
<h2>Logbook and user system</h2>
<p>It can be handled by ASP.NET Identity</p>
<h2>Database tables</h2>
<small>Some parts have been added lately, they're not icluded (yet)</small>
<img src="https://user-images.githubusercontent.com/71689781/188394797-03232a1d-75b5-459e-b46a-eb16602121cd.jpg">
