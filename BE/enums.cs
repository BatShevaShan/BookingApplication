using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{//the enums of the classs
    public enum Area { All, North, South, Center, Jerusalem }
    public enum Request { Possible, NotInterested, Necessary }
    public enum TypeOfUnit { Zimmer, Hotel, Camping }
    public enum StatusGuestRequest { Open, CloseThroughTheSite, ClosedBecauseExpired }
    public enum StatusOrder { NotTreated, MailHasBeenSent, ClosesNoResponse, ClosesWithResponse }
}
