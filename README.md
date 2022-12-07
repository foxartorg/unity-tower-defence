[//]: # (https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

# [unity-tower-defence](https://github.com/foxartorg/unity-tower-defence)

## Request for Comments

### classes

All classes that can instantiate dynamic object should be extended from **Assets/Scripts/Common/MonoBehaviourSingleton.cs**

To access public properties use getter **Instance** from outside

### fields

[SerializeField] should be used only to connect prefabs or expose foreign variables

### structure

```c#
public class MyClass : MonoBehaviourSingleton {
    [SerializeField] private GameObject myGameObject;

    public void Awake() {
        // use to set up fields
    }
    
    public void Start() {
        // use to put logic
    }
}
```
