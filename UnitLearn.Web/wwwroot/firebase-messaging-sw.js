importScripts('https://www.gstatic.com/firebasejs/5.5.7/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/5.5.7/firebase-messaging.js');


var config = {
    apiKey: "AIzaSyA1Euvb9lOeT_Pb0STLGAH62M0pDWJlEE8",
    authDomain: "oomnotification.firebaseapp.com",
    databaseURL: "https://oomnotification.firebaseio.com",
    projectId: "oomnotification",
    storageBucket: "oomnotification.appspot.com",
    messagingSenderId: "1048805047969",
    appId: "1:1048805047969:web:f69da323ca8fec7fb73ae0",
    measurementId: "G-ZGC7CXYGTJ"
};

firebase.initializeApp(config);

const messaging = firebase.messaging();
