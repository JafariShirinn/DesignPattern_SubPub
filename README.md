# DesignPattern_SubPub
This is an example for pub/sub design pattern implementation in C#
for cosumind the API you need provide a model conains Date and Teperature in celsios.
After calling the post API the forecast will transformed and the transport to all media that have registerd in broadcasting service.
Then each medium will published the forecast in a xml file.
So far this solution contains 3 media (newspapar, radiostation, socialmedia).
