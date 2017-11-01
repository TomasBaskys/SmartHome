var listener = "http://localhost:60024/";

function getCommand(){

  $.post( listener, {}, function(response){
    openYoutubeVideo(response);
  });
}

function openYoutubeVideo(url){

  LeaveOneYoutubeTab(function(tabId){
    if (tabId === undefined){
      chrome.tabs.create({url: url});
    }
    else{
      chrome.tabs.update(tabId, {url: url})
    }
  });
}

function LeaveOneYoutubeTab(fn){

  var firstTabId;
  var firstTab = true;

  chrome.tabs.query({url: "https://www.youtube.com/*"}, function(tabs){

    tabs.forEach(function(tab){
      if (!firstTab) {
        chrome.tabs.remove(tab.id);
      }
      else {
        firstTabId = tab.id;
      }
      firstTab = false;
    });

    fn(firstTabId);
  });
}

function onLoad() {
  setInterval(getCommand, 1000);
}

document.addEventListener('DOMContentLoaded', onLoad);