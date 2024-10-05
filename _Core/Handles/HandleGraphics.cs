using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandleGraphics
{
    public static Texture2D CreateTexture2D(RenderTexture input, Camera targetCamera = null)
    {
        RenderTexture currentRender = RenderTexture.active;
        RenderTexture.active = input;

        if (targetCamera)
        {
            targetCamera.Render();
        }
        else
        {
            Camera.current.Render();
        }

        Texture2D newTexture = new Texture2D(input.width, input.height);
        newTexture.ReadPixels(new Rect(0, 0, newTexture.width, newTexture.height), 0, 0);
        newTexture.Apply();

        RenderTexture.active = currentRender;
        return newTexture;
    }

    public static byte[] CreatePNG(RenderTexture input, Camera targetCamera = null)
    {
        Texture2D processedTexture = CreateTexture2D(input, targetCamera);
        return processedTexture.EncodeToPNG();
    }

    public static Sprite CreateSprite(RenderTexture input, Camera targetCamera = null)
    {
        Texture2D processedTexture = CreateTexture2D(input, targetCamera);
        return Sprite.Create(processedTexture, new Rect(0, 0, processedTexture.width, processedTexture.height), new Vector2(0.5f, 0.5f));
    }
}
