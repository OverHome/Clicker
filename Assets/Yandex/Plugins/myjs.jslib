mergeInto(LibraryManager.library, {
   ShowAdv:function(){
   if(typeof ysdk !== 'undefined'){
    SendMessage('MainMusic', 'MuteSound');
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {
          SendMessage('MainMusic', 'UnmuteSound');
        },
        onError: function(error) {
         SendMessage('MainMusic', 'UnmuteSound');
          // some action on error
        }
        }
        })
        }
   },
   
   ShowRew:function(){
    if(typeof ysdk !== 'undefined'){
    isReward = false;
     ysdk.adv.showRewardedVideo({
         callbacks: {
             onOpen: () => {
              SendMessage('MainMusic', 'MuteSound');
               console.log('Video ad open.');
             },
             onRewarded: () => {
               console.log('Rewarded!');
               isReward = true;
             },
             onClose: () => {
              SendMessage('MainMusic', 'UnmuteSound');
               console.log('Video ad closed.');
               if(isReward){
                 SendMessage('Main Camera', 'SetX2');
               }
             }, 
             onError: (e) => {
              SendMessage('MainMusic', 'UnmuteSound');
              SendMessage('Main Camera', 'StopX2');
               console.log('Error while open video ad:', e);
             }
         }
     })
     }
     },
     
   SaveExtern:function(data){
    if(typeof ysdk !== 'undefined'){
     var dataStr = UTF8ToString(data);
     var myobj = JSON.parse(dataStr);
     if(typeof player !== 'undefined'){
      player.setData(myobj, true);
      if(ysdk.isAvailableMethod('leaderboards.setLeaderboardScore')){
        ysdk.getLeaderboards()
              .then(lb => {
                lb.setLeaderboardScore('lb1', myobj.ClickCount);
              });
     }
     }
    }
     },
     
    LoadExtern:function(){
     if(typeof ysdk !== 'undefined'){
      if(typeof player !== 'undefined'){
      player.getData().then(_date=>{
        const myJSON = JSON.stringify(_date);
        SendMessage('Main Camera', 'LoadData', myJSON);
      });
      }else{
        SendMessage('Main Camera', 'LoadData', "{}");
      }
      }else{
        SendMessage('Main Camera', 'LoadData', "{}");
      }
    },
    
    GetLang:function(){
    if(typeof ysdk !== 'undefined'){
        var returnStr = ysdk.environment.i18n.lang;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    }
    }
});