import React, { useState } from "react";
import { getUrlShortLink } from "../api/api_shortener";

export const UrlShortener = () => {
  const [text, setText] = useState("");
  const [finalShortLink, setFinalShortLink] = useState("");
  const [submitBtnContent, setSubmitBtnContent] = useState("Generate New Url");

  const onSubmitClicked = () => {
    getUrlShortLink(text).then((res) => {
        setSubmitBtnContent("inProgress")
      if (res.isSuccess == true) {
        setFinalShortLink(res.data.finalUrl);
        setSubmitBtnContent("Generate New Url");
     
      }
    });
  };

  return (
    <div>
      <label for="url">Your Short url</label>
      <input
        type="text"
        id="url"
        value={text}
        onChange={(e) => setText(e.target.value)}
        name="url"
        placeholder="enter url.."
      />
      
      <button onClick={onSubmitClicked}>{submitBtnContent}</button>
      <h6>Short Link: {finalShortLink}</h6>
    </div>
  );
};
