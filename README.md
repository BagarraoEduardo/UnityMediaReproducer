# Unity Media Reproducer

![Project Banner](/media/project-banner.png)


Hi, this is a project where a Unity Game reproduces an audio file that I download and stream from a REST API.

- The projects on this repo:
    - MediaAPI:
        - It's a REST API implemented using Clean Architechture;
        - It has only a service, one that retrieves an audio file in the .wav format.
    - MediaReproducer:
        - It's a simple game made in Unity where you control a ball, and you have 2 platforms;
        - If you step on the grey one, it will download an audio file from MediaAPI and reproduce it on the game;
        - Setting on the white one will also reproduce the same audio file from MediaAPI, but the file will be streamed instead of downloaded.

I have here a diagram that shows better how this project works:

![Project Diagram](/media/project-diagram.png)

You can also see this video that I recorded that shows this working:

[![IMAGE ALT TEXT HERE](https://img.youtube.com/vi/V100rlCYnU0/0.jpg)](https://youtu.be/V100rlCYnU0)

Hope you enjoy! If you are interested in discussing any idea, you can contact me through my [portfolio](https://www.eduardobagarrao.com) or [email me](mailto:general@eduardobagarrao.com)! 



# Credits

The song that is used in this game is the Level 1, in the 5 Action Chiptunes, made by Juhani Junkala. You can find them [here](https://opengameart.org/content/5-chiptunes-action).