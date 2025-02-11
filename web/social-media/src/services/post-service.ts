import { PaginatedPosts, PostOrderBy } from "@/type/api/post";
import axios from "axios";

const API_URL = "http://localhost:8080/api/Post";


export async function fetchPosts(
  orderBy: PostOrderBy,
  keyword: string,
  pageParam: number = 1
) {
  const pageSize = pageParam === 1 ? 15 : 20;
  const { data } = await axios.get<PaginatedPosts>(
    `${API_URL}?page=${pageParam}&pageSize=${pageSize}&orderBy=${orderBy}&keyword=${keyword}`
  );
  const hasMore = pageParam * pageSize < data.totalCount;

  return {
    posts: data.items,
    nextPage: hasMore ? pageParam + 1 : null,
  };
}

export async function createPost(postData: {
  content: string;
  authorUserId: number;
}) {
  const response = await axios.post(API_URL, postData);
  return response.data;
}

export async function createRepost(postData: {
  originalPostId: number;
  authorUserId: number;
}) {
  const payload = { authorUserId: postData.authorUserId };

  const response = await axios.post(
    `${API_URL}/${postData.originalPostId}/repost`,
    payload
  );

  return response.data;
}
