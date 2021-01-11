# EventManager

This Event Manager is made special for small-medium Unity games where simplicity is preferred over performance.

Usage:
1. Copy the file in your Unity project;
2. Add the EventManager.cs to a GameObject in your Scene (GameManager or EventManager preferred);
3. Declare your events in EventName enum;
4. You can Subscribe and Unsubscribe really easy by using StartListening and StopListening methods;
5. Use TriggerEvent method to trigger the event you wish for;

Advantages:
- Easy to add in a project;
- Easy to use;
- Using dynamic keyword you can use primitive types or complex objects really easy;

Disadvantages:
- It has a lower performance:
  - For 1000 events triggered sincroniously:
    - **dynamic**: aprox. 350 miliseconds;
    - **string**: aprox. 130 miliseconds;
    - **int**: aprox, 130 miliseconds;
    - **object**: aprox. 150 miliseconds;
- Not having the parameteres stronged typed the errors in using wrong the models can be seen only at runtime;
