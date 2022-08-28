import React, { useState } from "react";
import { getUrlOrginalLink } from "../api/api_shortener";
import "./style.css";

export const UrlRedirector = () => {
  const [text, setText] = useState("");
  const [finalOrigLink, setFinalOrigLink] = useState("");
  const [submitBtnContent, setSubmitBtnContent] = useState("Go");

  const onSubmitClicked = ()=>{
    getUrlOrginalLink(text)
    .then(res=>{
      setSubmitBtnContent("inProgress")
      if (res.isSuccess == true) {
        setFinalOrigLink(res.data.originalUrl);
        setSubmitBtnContent("Go");
        window.open(
          res.data.originalUrl, "_blank");
      }
    });
  }

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
      <h6>Original Link: {finalOrigLink}</h6>
    </div>
  );
};
