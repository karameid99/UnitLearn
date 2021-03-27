const firebaseConfig = {
    apiKey: "AIzaSyA1Euvb9lOeT_Pb0STLGAH62M0pDWJlEE8",
    authDomain: "oomnotification.firebaseapp.com",
    databaseURL: "https://oomnotification.firebaseio.com",
    projectId: "oomnotification",
    storageBucket: "oomnotification.appspot.com",
    messagingSenderId: "1048805047969",
    appId: "1:1048805047969:web:f69da323ca8fec7fb73ae0",
    measurementId: "G-ZGC7CXYGTJ"
};

firebase.initializeApp(firebaseConfig);

const messaging = firebase.messaging();



// messaging.onMessage(payload => {
//     // ShowMessage("s:New Notification");
//     // var audio = new Audio('/Audio/slow-spring-board-longer-tail.mp3');
//     // audio.play();
//     // audio.remove();
//     console.log(payload);
// });

