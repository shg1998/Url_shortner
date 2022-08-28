import {getAxiosBase} from "./index";

export const getUrlShortLink = (url) => {
    return getAxiosBase().get(`/UrlShortener/get-url-short-link?url=${url}`).then(res => res.data).catch(err => {
        throw new Error(err.response.data);
    });
};


export const getUrlOrginalLink = (url) => {
    return getAxiosBase().get(`/UrlShortener/get-url-orig-link?url=${url}`).then(res => res.data).catch(err => {
        throw new Error(err.response.data);
    });
};