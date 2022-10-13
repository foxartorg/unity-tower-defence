# unity-tower-defence

## Instructions

### Run project

in **Unity Editor** on **Project** tab
in **Assets/Scenes** folder
select **MainScene** or **GameScene** and press play button

## Request for Comments

### Manager class
all classes that can instantiate dynamic object
should be extended from **Assets/Common/Manager**
and implement getter **Instance** as described

```c#
using Common;

public class MyObjectManager : Manager {
    [SerializeField] private GameObject myGameObject;
    public static MyObjectManager Instance { get; private set; }

    public void Awake() {
        Instance = this.SingleInstance<MyObjectManager>(this, Instance);
    }
    
    public GameObject Create(Transform parentTransform) {
        var vector3 = Helper.PositionUpFromParent(this.myGameObject.transform, parentTransform);
        return Instantiate(this.myGameObject, vector3, parentTransform.rotation, this.transform);
    }
    
    // you code goes here
}
```
