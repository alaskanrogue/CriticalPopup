# CriticalPopup
Error demonstration project for critical popups
This project was created to debug two errors:

  1) CommunityToolkit.Maui.Views.Popup Button Text Alignment #1489
  2) Maui Popup Randomly Disrupts the Transitional View #1488

  The first bug regards the horizontal positioning of the label of the popup if the calling content page is in the background on a Maui Android phone. The 'Click me' button on the main page begins the creation of the popup, but delays the action for 30 secs in order to provide time to move the app into the background. After thirty secs, the popup should be active and viewable if the app is brought back to the foreground.

  The second bug regards the random distruption of the content page view transfered to as a result of executing the botton of a popup, where it appears that the layout parameters are reset/deleted. If the destination page is not disrupted, two buttons are present that will return the app to the mainpage. Otherwise, the disrupted page will only display the two spans(?) of the page. The page layout is a simulation of a page in the effected app.
