using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Oekaki : MonoBehaviour {

    /// <summary>
    /// 描く線のコンポーネントリスト
    /// </summary>
    private List<LineRenderer> lineRendererList;

    /// <summary>
    /// 描く線のマテリアル
    /// </summary>
    public Material lineMaterial;

    /// <summary>
    /// 描く線の色
    /// </summary>
    public Color lineColor;

    /// <summary>
    /// 描く線の太さ
    /// </summary>
    [Range(0,10)] public float lineWidth;


    void Awake () {
        lineRendererList = new List<LineRenderer>();
    }

    bool isDraw = false;

    void Update () {

        // ボタンが押されている時、LineRendererに位置データの設定を指定していく
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if(!isDraw) {
                    isDraw = true;
                    this.AddLineObject();
                } else {
                    this.AddPositionDataToLineRendererList();
                }
            } else {
                isDraw = false;
            }
        }
    }

    /// <summary>
    /// 線オブジェクトの追加を行うメソッド
    /// </summary>
    private void AddLineObject () {

        // 追加するオブジェクトをインスタンス
        GameObject lineObject = new GameObject();

        // オブジェクトにLineRendererを取り付ける
        lineObject.AddComponent<LineRenderer>();

        // 描く線のコンポーネントリストに追加する
        lineRendererList.Add(lineObject.GetComponent<LineRenderer>());

        // 線と線をつなぐ点の数を0に初期化
        lineRendererList.Last().positionCount = 0;

        // マテリアルを初期化
        lineRendererList.Last().material = this.lineMaterial;

        // 線の色を初期化
        lineRendererList.Last().material.color = this.lineColor;

        // 線の太さを初期化
        lineRendererList.Last().startWidth = this.lineWidth;
        lineRendererList.Last().endWidth   = this.lineWidth;

        lineRendererList.Last().numCapVertices = 10;
        lineRendererList.Last().numCornerVertices = 10;
    }

    /// <summary>
    /// 描く線のコンポーネントリストに位置情報を登録していく
    /// </summary>
    private void AddPositionDataToLineRendererList () {

        // 座標の変換を行いマウス位置を取得
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane + 1.0f);
        var mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // 線と線をつなぐ点の数を更新
        lineRendererList.Last().positionCount += 1;

        // 描く線のコンポーネントリストを更新
        lineRendererList.Last().SetPosition(lineRendererList.Last().positionCount - 1, mousePosition);
    }
}