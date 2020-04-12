# AI-powered-tools-for-artists

## Resources and People to follow

Memo Akten
Anna Ridler
[Golan Levin](http://www.flong.com/)
[Gene Kogan](https://genekogan.com/)
- [Machine Learning for Artists](https://ml4a.github.io/)
Rebecca Fiebrink
Mario Klingemann
Patrick Tresset
[Kyle McDonald](http://kylemcdonald.net/)
[Daniel Shiffman](https://shiffman.net/)
- [Coding Train](https://www.youtube.com/user/shiffman)


## TOOLS

### Wekinator - Classification

Wekinator: http://www.wekinator.org/downloads/

OSC Input: [FaceOSC](http://www.doc.gold.ac.uk/~mas01rf/WekinatorDownloads/wekinator_examples/executables/mac/inputs/VideoInput_FacialExpression_oF_14Inputs.zip)  ([source](https://github.com/genekogan/ofxFaceTracker))\
OSC Output: [FM synthesis](http://www.doc.gold.ac.uk/~mas01rf/WekinatorDownloads/wekinator_examples/executables/mac/outputs/Processing_FMSynth_3ContinuousOutputs_Mac.zip) ([source](http://www.doc.gold.ac.uk/~mas01rf/WekinatorDownloads/wekinator_examples/all_source_zips/Processing_FMSynth_3ContinuousOutputs.zip))


For more examples check the wekinator [examples page](http://www.wekinator.org/examples/)

### ML5.js

### RunwayML   

Download [here](https://runwayml.com/download)\
After creating an account you will get 10$ free GPU credits\
Join them on [SLACK](https://runwayml.com/joinslack) and follow them on [Twitter](https://twitter.com/runwayml)

Install the [Photoshop plugin](https://github.com/runwayml/RunwayML-for-Photoshop/releases) and other integrations [here](https://runwayml.com/integrations)

#### - UNITY
- Create a new project
- Download the Socket.IO for Unity Asset from Asset Store and import
- (optional) Download Gridbox Prototype Materials from Asset Stroe and import 
- Go to ASSETS>SocketIO>Scenes and open the SocketIOTest
- Open RunwayML and create a Posenet project
- Select camera and reduce the resolution of the Width to 200 and flip vertically 
- Under the Network Tab select Socket.io and keep a note of the port
- Go Back to Unity and click SocketIO in the hierachy window
- In the Inspector tab under the Socket IO Component (Script) change the Port of the URL to the URL you got from Runway
- Edit the TestSocketIO script under ASSETS>SocketIO>Test
- The various stages of the code along with the assets used can be found in the unity folder

