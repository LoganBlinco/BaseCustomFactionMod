using BaseCustomFactions;
using HoldfastSharedMethods;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

namespace CustomFaction.Editor
{
    [Category("CustomFactions")]
    public class SpawnFactionObjectsTest
    {
        [Test]
        public void inputting_void_disables_it()
        {
            var instance = new SpawnFactionObjects(null, null, null, null, null,null, FactionCountry.British, FactionCountry.French);
            
            Assert.IsFalse(instance.IsValid);
        }

        [Test]
        public void inputting_non_null_enables_it()
        {
            Image imageMock = new GameObject().AddComponent<Image>();
            var instance = new SpawnFactionObjects(imageMock, imageMock, imageMock, imageMock, imageMock,null, FactionCountry.British, FactionCountry.French);
            Assert.IsTrue(instance.IsValid);
        }

        [Test]
        public void replacing_one_faction_works()
        {
            Image imageMock = new GameObject().AddComponent<Image>();
            Image imageMock2 = new GameObject().AddComponent<Image>();

            var instance = new SpawnFactionObjects(imageMock, imageMock, imageMock2, imageMock2, imageMock,null, FactionCountry.British, FactionCountry.French);

            Sprite sprite = Sprite.Create(
                new Texture2D(1,1),
                new Rect(0,0,1,1),
                Vector2.zero);
            
            instance.Replace(sprite,sprite,null,null);
            
            Assert.AreEqual(imageMock.overrideSprite,imageMock.overrideSprite);
            Assert.AreEqual(imageMock2.overrideSprite,null);
            
        }

    }
}