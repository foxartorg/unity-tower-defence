# [unity-tower-defence](https://github.com/foxartorg/unity-tower-defence)

[//]: # (https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet)

## Instructions

## Request for Comments

### classes
all classes that can instantiate dynamic object
should be extended from **Assets/Scripts/Common/MonoBehaviourSingleton.cs**
and use getter **Instance** to access public properties

### fields
[SerializeField] should be used only to connect prefabs or expose foreign variables

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
