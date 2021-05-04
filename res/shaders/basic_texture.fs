#version 430

uniform sampler2D tex;
uniform vec4 color;

//layout (location = 0) in vec4 gl_FragCoord
layout (location = 1) in vec2 v_uv;

layout (location = 0) out vec4 frag_color;
layout (location = 1) out vec4 frag_coord;

void main() {
    frag_color = color * texture(tex, v_uv);
    frag_coord = gl_FragCoord;
}